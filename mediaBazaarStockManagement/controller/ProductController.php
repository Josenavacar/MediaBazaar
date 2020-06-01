<?php
	require(ROOT . "model/ProductModel.php");
    require(ROOT . "model/CategoryModel.php");

    /**
     * Method to view products
     * @return [type] [description]
     */
	function index()
	{
		$products = getAllProducts();
		render("products/view", array('products' => $products));	
	}

    /**
     * Method to view a product
     * @param  [type] $product_id [description]
     * @return [type]             [description]
     */
    function product($product_id)
    {
        render("products/product", array('products' => getProductInfo($product_id)));
    }

    /**
     * Method to view add product page and all categories
     */
    function add()
    {
        render("products/add", array("categories" => getAllCategories()));
    }

    /**
     * Method to send request to model to add product
     */
    function addRequest()
    {
        if (isset($_POST['add'])) 
        {
            $data = $_POST['add'];
            addProduct($data);
        }
    }

    /**
     * Method to view edit product page
     * @param  [type] $product_id [description]
     * @return [type]             [description]
     */
    function edit($product_id)
    {
        $product = getProduct($product_id);
        render("products/edit", array('product' => $product));
    }

    /**
     * Method to send request to model for editing product
     * @return [type] [description]
     */
    function editRequest()
    {
        if (isset($_POST['edit'])) 
        {
            $data = $_POST['edit'];
            editProduct($data);
        }
    }
?>