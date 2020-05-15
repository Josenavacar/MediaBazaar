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

    function edit($category_id)
    {
        render("categories/edit", array('category' => getCategory($category_id)));
    }

    function add()
    {
        render("categories/add");
    }

    function addRequest()
    {
        if (isset($_POST['data'])) 
        {
            $data = $_POST['data'];
            addCategory($data);
        }
    }

    function editRequest()
    {
        if (isset($_POST['data'])) 
        {
            $data = $_POST['data'];
            editCategory($data);
        }
    }
?>