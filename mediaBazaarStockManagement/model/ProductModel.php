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
