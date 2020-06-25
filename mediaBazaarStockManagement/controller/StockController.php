<?php
	require(ROOT . "model/ProductModel.php");
	require(ROOT . "model/DepartmentModel.php");
	require(ROOT . "model/InventoryModel.php");

	/**
	 * Method to view stock request page
	 * @return [type] [description]
	 */
	function index()
	{
		$products = getAllProducts();
		$departments = getAllDepartments();
		render("stocks/index", array('products' => $products, 'departments' => $departments));	
	}

	/**
	 * Method to send request to model to place stock request
	 * @return [type] [description]
	 */
	function stockRequest()
	{		
		if (isset($_POST['data'])) 
		{
		    $data = $_POST['data'];
		    makeRequest($data);
		}
	}