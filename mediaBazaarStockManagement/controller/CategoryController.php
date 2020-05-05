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

    function add()
    {
        $categories = getAllCategories();
        render("categories/add", array('categories' => $categories));
    }

    function addRequest()
    {
        if (isset($_POST['data'])) 
        {
            $data = $_POST['data'];
            addCategory($data);

            // print_r(date("Y-m-d H:i:s"));
            // response_array['status'] = 'status123';
            // echo json_encode($response_array);
        }
    }
?>