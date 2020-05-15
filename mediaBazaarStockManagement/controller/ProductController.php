<?php
	require(ROOT . "model/ProductModel.php");

	function index()
	{
		$products = getAllProducts();
		render("products/view", array('products' => $products));	
	}

    function product($product_id)
    {
    	render("products/product", array('products' => getFullProduct($product_id)));
    }
?>