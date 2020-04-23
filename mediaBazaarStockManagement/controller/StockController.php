<?php
	require(ROOT . "model/ProductModel.php");
	require(ROOT . "model/DepartmentModel.php");
	require(ROOT . "model/InventoryModel.php");

	function index()
	{
		$products = getAllProducts();
		$departments = getAllDepartments();
		render("stocks/index", array('products' => $products, 'departments' => $departments));	
	}

	function stockrequest()
	{		
		$results = [];
		if (isset($_POST['data'])) 
		{
		    $data = $_POST['data'];
		    makeRequest($data);

		    // print_r(date("Y-m-d H:i:s"));
  			// response_array['status'] = 'status123';
    		// echo json_encode($response_array);
		}
	}