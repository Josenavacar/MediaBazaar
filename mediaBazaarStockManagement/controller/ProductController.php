<?php
	require(ROOT . "model/ProductModel.php");

	function index()
	{
		$products = getAllProducts();
		render("products/view", array('products' => $products));	
	}
?>