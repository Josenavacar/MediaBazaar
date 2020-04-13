<?php
    function index()
    {
        $orders = getAllOrders();
		render("orders/view", array('orders' => $orders));	
    }
?>