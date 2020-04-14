<?php
	require(ROOT . "model/ProductModel.php");
	require(ROOT . "model/DepartmentModel.php");
	require(ROOT . "model/InventoryModel.php");

	function index()
	{
		$products = getAllProducts();
		$departments = getAllDepartments();
		render("stock/request", array('products' => $products, 'departments' => $departments));	
	}

	function stockrequest()
	{		
		 // print_r($order = json_decode($_POST['data'], true));
		// return $order;
		// 
		if (isset($_POST['data'])) {
		    $data = $_POST['data'];

		    foreach ($data as $value) {

		        // Same here...
		        echo $value;
		        return $value;
		    }
		    // result();
		}
	}

	function result()
	{
		$data = stockrequest();
		echo $data;
		render("stock/result");
	}