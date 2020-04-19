<?php
    require(ROOT . "model/CategoryModel.php");

    function index()
    {
        $categories = getAllProductsPerCategory();
		render("category/view", array('categories' => $categories));	
    }
?>