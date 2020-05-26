<?php
	require(ROOT . "model/UserModel.php");

	function index()
	{
		render("home/login");	
	}

	function loginRequest()
	{
        if (isset($_POST['data'])) 
        {
            $data = $_POST['data'];
            userLogin($data);
        }
	}

	function loginCodeRequest()
	{
        if (isset($_POST['data'])) 
        {
            $data = $_POST['data'];
            if($_SESSION["special_code"] == $data['value'])
            {
            	echo "success";
            }
            else
            {
            	echo "error";
            }
        }
	}

	function logout()
	{
		// Initialize the session
		session_start();
		 
		// Unset all of the session variables
		session_unset();
		 
		// Destroy the session.
		session_destroy();
		 
		// Redirect to login page
		header("Location:" . URL . "login");
		exit;
	}