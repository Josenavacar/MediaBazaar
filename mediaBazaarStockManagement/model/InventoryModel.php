<?php
	require(ROOT . "model/UserModel.php");
	require(ROOT . "model/EmailModel.php");

	function getAllInventory()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT product.Id, product.Name, product.Price, inventory.UnitsInStock FROM inventory INNER JOIN product ON inventory.ProductID = product.ID";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	function makeRequest($data)
	{
		foreach ($data as $key => $value) {

			if($key == 'email')
			{
				$user = getUserByEmail($value);

				if($user != null)
				{
					$department = getDepartment($data['department']);
					$product = getProduct($data['product']);
					$quantity = $data['quantity'];
					$total_price = (double)$data['totalPrice'];
					$depId = $department['Id'];

					$db = openDatabaseConnection();
					$sql = "INSERT INTO `order` (DepartmentID) VALUES (:depId)";
					$query = $db->prepare($sql);
					$query->bindParam(":depId", $depId, PDO::PARAM_INT);
					$query->execute();
					$latest_id = $db->lastInsertId();

					$sql2 = 'INSERT INTO product_order (Quantity, TotalPrice, ProductID, OrderID) VALUES (:quantity, :total_price, :product, :last_insert_id)';
					$query = $db->prepare($sql2);
					$query->bindParam(":quantity", $quantity, PDO::PARAM_INT);
					$query->bindValue(":total_price", $total_price);
					$query->bindParam(":product", $product['Id'], PDO::PARAM_INT);
					$query->bindValue(":last_insert_id", $latest_id);
					$query->execute();

					$sql3 = 'UPDATE inventory SET UnitsInStock = UnitsInStock + :quantity WHERE ProductID = :product';
					$query = $db->prepare($sql3);
					$query->bindParam(":quantity", $quantity, PDO::PARAM_INT);
					$query->bindParam(":product", $product['Id'], PDO::PARAM_INT);
					$query->execute();

					sendEmail($data['email'], $latest_id);
					$db = null;
					return $latest_id;
				}
				else
				{
					echo "User not found!";
				}
			}
		}
	}
