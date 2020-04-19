<?php
    function getAllProductsPerCategory()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT product.*, category.Name AS Category FROM category INNER JOIN product ON category.Id = product.CategoryID;";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();
    }
?>