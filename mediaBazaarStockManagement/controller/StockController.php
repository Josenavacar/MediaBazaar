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
		$results = [];
		if (isset($_POST['data'])) {
		    $data = $_POST['data'];
		    returnRequest($data);
		}
	}