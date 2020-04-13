<?php
    function route()
    {
        $url = splitUrl();

        // if url['controller'] (ProductController) doesnt exist then redirect to homepage
        if (!isset($url['controller'])) 
        { 
            require(ROOT . 'controller/LoginController.php');
            // call index function in homecontroller
            call_user_func('index'); 

        }
        elseif (file_exists(ROOT . 'controller/' . $url['controller'] . '.php')) 
        {
            require(ROOT . 'controller/' . $url['controller'] . '.php');

            // The call_user_func_array() function is a special way to call an existing PHP function. It takes a function to call as its first parameter, then takes an array of parameters as its second parameter.
            if (function_exists($url['action'])) 
            {
                if ($url['params']) 
                {
                    call_user_func_array($url['action'], $url['params']);
                } 
                else 
                {
                    call_user_func($url['action']);
                }
            }
            else
            {
                echo "Not available.";
            } 
        }
    }

    function splitUrl()
    {
        if (isset($_GET['url'])) 
        {
            $tmp_url = trim($_GET['url'], "/");
            //The FILTER_SANITIZE_URL filter removes all illegal URL characters from a string.
            //This filter allows all letters, digits and $-_.+!*'(),{}|\\^~[]`"><#%;/?:@&=
            $tmp_url = filter_var($tmp_url, FILTER_SANITIZE_URL);
            //The explode() function breaks a string into an array.
            $tmp_url = explode("/", $tmp_url);
            // get controller name
            $url['controller'] = isset($tmp_url[0]) ? ucwords($tmp_url[0] . 'Controller') : null;
            // get the action
            $url['action'] = isset($tmp_url[1]) ? $tmp_url[1] : 'index';
            // The unset() function unsets a variable.
            unset($tmp_url[0], $tmp_url[1]);
            // This inbuilt function in PHP is used to get an array of values from another array that may contain key-value pairs or just values. The function creates another array where it stores all the values and by default assigns numerical keys to the values.
            $url['params'] = array_values($tmp_url);

            return $url;    
        }   
    }
?>