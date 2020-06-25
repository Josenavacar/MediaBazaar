<?php
    require(ROOT . "model/OrderModel.php");

    /**
     * Method to view orders
     * @return [type] [description]
     */
    function index()
    {
        $orders = getAllOrders();
		render("orders/view", array('orders' => $orders));	
    }
?>