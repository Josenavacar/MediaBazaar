<?php
	function getAllProducts(){
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM person";
		$query = $db->prepare($sql);
		$query->execute();

		$db = null;
		
		return $query->fetchAll();
	}
