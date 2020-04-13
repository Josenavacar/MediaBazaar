<?php
    function getAllOrders()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT * FROM product_order;";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
    }