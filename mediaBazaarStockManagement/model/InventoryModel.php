<?php
	function getAllInventory(){
		$db = openDatabaseConnection();
		$sql = "SELECT product.Name, product.Price, inventory.UnitsInStock FROM inventory INNER JOIN product ON inventory.ProductID = product.ID";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	function createRequest()
	{
		$db = openDatabaseConnection();
		$sql = "INSERT";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return true;
	}