<?php
	function getAllDepartments()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM department";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	function getDepartment($department)
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM department WHERE name = :department";
		$query = $db->prepare($sql);
		$query->execute(array(":department" => $department));
		$db = null;
		return $query->fetch();		
	}