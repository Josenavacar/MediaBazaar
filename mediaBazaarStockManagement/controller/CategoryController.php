<?php
    require(ROOT . "model/CategoryModel.php");

    function index()
    {
        $categories = getAllCategories();
		render("categories/view", array('categories' => $categories));	
    }

    function product($category_id)
    {
    	render("categories/product", array('products' => getProducts($category_id)));
    }

    function addProduct()
    {
        render("categories/add");
    }
?>