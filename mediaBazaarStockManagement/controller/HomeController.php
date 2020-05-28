<?php
	require(ROOT . "model/InventoryModel.php");
	require(ROOT . "model/OrderModel.php");
	require(ROOT . "model/CategoryModel.php");
	require(ROOT . "model/ProductModel.php");

	function index()
	{
		$units = getAllInventory();
		$orders = getAllOrders();
		$duplicateProducts = getOrdersWithMultipleOccuringProducts();
		$products = getAllProducts();
		$categories = getAllCategories();

		$bestSellingProducts = array();
		foreach ($duplicateProducts as $key => $value) 
		{
			$bestSellingProducts[] = $value;
		}

		$ordersPerMonth = array();
		foreach ($orders as $key => $value) 
		{
			$currentMonth = date('m');
			$orderMonth = date('m', strtotime($value['OrderDate']));

			if ($currentMonth == $orderMonth) 
			{
				$ordersPerMonth[] = $value['OrderDate'];
			}
		}
		
		render("home/index", array
								(	
									'units' => $units, 
									'orders' => $orders, 
									'bestSellingProducts' => $bestSellingProducts, 
									'ordersPerMonth' => $ordersPerMonth, 
									'products' => $products, 
									'categories' => $categories
								));	
	}
?>