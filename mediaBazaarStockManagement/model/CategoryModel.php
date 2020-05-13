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

    function getCategory($category_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT * FROM category WHERE Id = :category_id";
        $query = $db->prepare($sql);
        $query->execute(array(":category_id" => $category_id));

        $db = null;
        return $query->fetch();   
    }

    function addCategory($data)
    {
        $db = openDatabaseConnection();
        $sql = 'INSERT INTO category (Name, Description) VALUES (:name, :description)';
        $query = $db->prepare($sql);
        $query->bindValue(":name", $data['name']);
        $query->bindValue(":description", $data['description']);
        $query->execute();
        // $latest_id = $db->lastInsertId();
        // echo $latest_id;
        $db = null;
        echo "success";
    }

    function editCategory($data)
    {
        $id = (int)$data['category_id'];
        $name = $data['name'];
        $description = $data['description'];

        $db = openDatabaseConnection();
        $sql = 'UPDATE category SET Name = :name, Description = :description WHERE Id = :categoryID';
        $query = $db->prepare($sql);
        $query->bindValue(":categoryID", $id);
        $query->bindValue(":name", $name);
        $query->bindValue(":description", $description);
        $query->execute();

        $db = null;
        echo "success";
    }
?>