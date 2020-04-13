<?php
	function getAllProducts(){
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM product";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}
