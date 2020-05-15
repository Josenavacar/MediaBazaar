<?php
	function getAllProducts()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM product";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	function getProduct($product)
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM product WHERE name = :product";
		$query = $db->prepare($sql);
		$query->execute(array(":product" => $product));

		$db = null;
		return $query->fetch();
	}

    function getFullProduct($product_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT product.*, category.Name AS Category FROM category INNER JOIN product ON category.Id = product.CategoryID 
        WHERE product.Id = :product_id";
        $query = $db->prepare($sql);
        $query->execute(array(":product_id" => $product_id));

        $db = null;

        return $query->fetchAll();  
    }
?>
