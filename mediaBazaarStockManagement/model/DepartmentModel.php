<?php
	function getAllDepartments(){
	$db = openDatabaseConnection();
	$sql = "SELECT * FROM department";
	$query = $db->prepare($sql);
	$query->execute();
	$db = null;
	return $query->fetchAll();
}