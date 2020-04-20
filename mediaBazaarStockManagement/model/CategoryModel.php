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

    function getAllCategories()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT * FROM category";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();   	
    }

    function getProducts($category_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT * FROM product WHERE product.CategoryID = :category_id";
        $query = $db->prepare($sql);
        $query->execute(array(":category_id" => $category_id));

        $db = null;

        return $query->fetchAll();  
    }
?>