<?php
	require_once(ROOT . "model/EmailModel.php");

	function generateLoginCode()
	{
		$length = 6;    
		$sessionID = substr(str_shuffle('0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ'),1,$length);
		return $sessionID;
	}

	function getAllUsers()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM person";
		$query = $db->prepare($sql);
		$query->execute();

		$db = null;
		
		return $query->fetchAll();
	}


	function userLogin($data)
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM person WHERE email = :email";
		$query = $db->prepare($sql);
		$query->execute(array(":email" => $data['email']));
		$row = $query->fetch(PDO::FETCH_ASSOC);

		if(!empty($row))
		{
			if(($row['Email'] == $data['email']) AND ($row['Passcode'] == $data['passcode']))
			{
				$_SESSION["user_id"] = $row['Id'];
				$_SESSION["user_name"] = $row['Email'];
				$_SESSION['loggedin_time'] = time();

				echo "success";  
				sendLoginCode($row['Email'], generateLoginCode());
			}
			else
			{
				echo "User not found";
			}
		}
		else
		{
			// Initialize the session			 
			// Unset all of the session variables
			session_unset();
			 
			// Destroy the session.
			session_destroy();
			echo "User not found";
		}

		$db = null;
	}

	function getUserByEmail($email)
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM person WHERE email = :email";
		$query = $db->prepare($sql);
		$query->execute(array(":email" => $email));

		$db = null;
		return $query->fetch();
	}
