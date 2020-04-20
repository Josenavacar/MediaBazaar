<?php
    function getAllOrders()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT product_order.OrderID, product.Name, product_order.Quantity, product_order.TotalPrice 
				FROM product_order 
				INNER JOIN product 
				ON product_order.ProductID = product.Id;";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();
    }
?>