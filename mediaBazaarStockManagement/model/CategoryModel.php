<?php

    /**
     * Method to get all categories
     * @return [type] [description]
     */
    function getAllCategories()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT * FROM category";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();   	
    }

    /**
     * Method to get products in the same category
     * @param  [type] $category_id [description]
     * @return [type]              [description]
     */
    function getProducts($category_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT * FROM product WHERE product.CategoryID = :category_id";
        $query = $db->prepare($sql);
        $query->execute(array(":category_id" => $category_id));

        $db = null;
        return $query->fetchAll();  
    }

    /**
     * Method to get category by ID
     * @param  [type] $category_id [description]
     * @return [type]              [description]
     */
    function getCategory($category_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT * FROM category WHERE Id = :category_id";
        $query = $db->prepare($sql);
        $query->execute(array(":category_id" => $category_id));

        $db = null;
        return $query->fetch();   
    }

    /**
     * Method to add category to the DB
     * @param [type] $data [description]
     */
    function addCategory($data)
    {
        $db = openDatabaseConnection();
        $sql = 'INSERT INTO category (Name, Description) VALUES (:name, :description)';
        $query = $db->prepare($sql);
        $query->bindValue(":name", $data['name']);
        $query->bindValue(":description", $data['description']);
        $query->execute();

        $db = null;
        echo "success";
    }

    /**
     * Method to edit a category
     * @param  [type] $data [description]
     * @return [type]       [description]
     */
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