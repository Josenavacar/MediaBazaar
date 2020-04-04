<?php
	require(ROOT . "model/ProductModel.php");

	function index()
	{
		$persons = getAllProducts();

		render("products/view", array('persons' => $persons));	
	}
?>