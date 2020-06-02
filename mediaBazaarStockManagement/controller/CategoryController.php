<?php
    require(ROOT . "model/CategoryModel.php");

    /**
     * Method to view categories
     * @return [type] [description]
     */
    function index()
    {
        $categories = getAllCategories();
		render("categories/view", array('categories' => $categories));	
    }

    /**
     * Method to view products in category
     * @param  [type] $category_id [description]
     * @return [type]              [description]
     */
    function product($category_id)
    {
    	render("categories/product", array('products' => getProducts($category_id)));
    }

    /**
     * Method to view add product page
     */
    function add()
    {
        render("categories/add");
    }

    /**
     * Method to send request to model to add category
     */
    function addRequest()
    {
        if (isset($_POST['add'])) 
        {
            $data = $_POST['add'];
            addCategory($data);
        }
    }

    /**
     * Method to view edit product page
     */
    function edit($category_id)
    {
        render("categories/edit", array('category' => getCategory($category_id)));
    }

    /**
     * Method to send request to model to edit category
     * @return [type] [description]
     */
    function editRequest()
    {
        if (isset($_POST['edit'])) 
        {
            $data = $_POST['edit'];
            editCategory($data);
        }
    }
?>