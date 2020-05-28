<?php
	require(ROOT . "model/InventoryModel.php");
	require(ROOT . "model/OrderModel.php");

	function index()
	{
		$units = getAllInventory();
		$orders = getAllOrders();
		$products = getOrdersWithMultipleOccuringProducts();

		$bestSellingProducts = array();
		foreach ($products as $key => $value) 
		{
			$bestSellingProducts[] = $value;
		}

		
		
		render("home/index", array('units' => $units, 'orders' => $orders, 'bestSellingProducts' => $bestSellingProducts));	
	}
?>