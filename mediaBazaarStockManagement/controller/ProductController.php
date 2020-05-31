<?php
	require(ROOT . "model/ProductModel.php");
    require(ROOT . "model/CategoryModel.php");

	function index()
	{
		$products = getAllProducts();
		render("products/view", array('products' => $products));	
	}

    function product($product_id)
    {
        render("products/product", array('products' => getFullProduct($product_id)));
    }

    function add()
    {
        render("products/add", array("categories" => getAllCategories()));
    }

    function addRequest()
    {
        if (isset($_POST['add'])) 
        {
            $data = $_POST['add'];
            addProduct($data);
        }
    }

    function edit($product_id)
    {
        $product = getProduct($product_id);
        render("products/edit", array('product' => $product));
    }

    function editRequest()
    {
        if (isset($_POST['edit'])) 
        {
            $data = $_POST['edit'];
            editProduct($data);
        }
    }
?>