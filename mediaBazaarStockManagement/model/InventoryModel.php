<?php
	require_once(ROOT . "model/UserModel.php");
	require_once(ROOT . "model/EmailModel.php");

	/**
	 * Method to get all products in inventory
	 * @return [type] [description]
	 */
	function getAllInventory()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT product.Id, product.Name, product.Price, inventory.UnitsInStock FROM inventory INNER JOIN product ON inventory.ProductID = product.ID";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	/**
	 * Method to make a new stock request
	 * @param  [type] $data [description]
	 * @return [type]       [description]
	 */
	function makeRequest($data)
	{
		$emailOrderID = '';
		$emailAddress = '';

		foreach ($data as $key => $value) 
		{
			if($key == 'email')
			{
				$user = getUserByEmail($value);

				if($user != null)
				{
				    date_default_timezone_set('Europe/Amsterdam');
			    	$orderDate = date("Y-m-d H:i:s");
					$department = getDepartment($data['department']);
					$product = getProductByName($data['product']);
					$product_id = (int)$product['Id'];
					$quantity = $data['quantity'];
					$total_price = (double)$data['totalPrice'];
					$depId = $department['Id'];

					$db = openDatabaseConnection();
					$sql = "INSERT INTO `order` (UserID, OrderDate, DepartmentID) VALUES (:userId, :orderDate, :depId)";
					$query = $db->prepare($sql);
					$query->bindParam(":userId", $user['Id'], PDO::PARAM_INT);
					$query->bindValue(":orderDate", $orderDate);
					$query->bindParam(":depId", $depId, PDO::PARAM_INT);
					$query->execute();
					$latest_id = $db->lastInsertId();

					$sql2 = 'INSERT INTO product_order (Quantity, TotalPrice, ProductID, OrderID) VALUES (:quantity, :total_price, :product, :last_insert_id)';
					$query = $db->prepare($sql2);
					$query->bindParam(":quantity", $quantity, PDO::PARAM_INT);
					$query->bindValue(":total_price", $total_price);
					$query->bindValue(":product", $product_id);
					$query->bindValue(":last_insert_id", $latest_id);
					$query->execute();

					$sql3 = 'UPDATE inventory SET UnitsInStock = UnitsInStock + :quantity WHERE ProductID = :product';
					$query = $db->prepare($sql3);
					$query->bindParam(":quantity", $quantity, PDO::PARAM_INT);
					$query->bindValue(":product", $product_id);
					$query->execute();

					$emailOrderID = $latest_id;
					$emailAddress = $data['email'];

					// session_start();
					$_SESSION['order_ID'] = $latest_id;
					echo $latest_id;
					$db = null;
					
				}
				else
				{
					echo "User not found!";
				}
			}
		}

		sendEmail($emailOrderID, $emailAddress);
	}
