<?php
	require(ROOT . "model/UserModel.php");

	function index()
	{
		render("home/login");	
	}

	function login()
	{
		if(!userLogin())
		{
			header("Location:" . URL . "login");
			exit();
		}
		else
		{
			header("Location:" . URL . "home");
			exit();
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