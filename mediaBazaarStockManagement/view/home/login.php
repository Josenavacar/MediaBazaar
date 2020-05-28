<div class="container-fluid">
    <div class="row align-items-center">
        <div class="col-12 col-md-6 offset-xl-2 offset-md-1 order-md-2 mb-5 mb-md-0">
            <!-- Image -->
            <div class="text-center">
                <img src="images/warehouse-industrial.jpg" alt="..." class="img-fluid">
            </div>
        </div>

        <div class="col-12 col-md-5 col-xl-4 order-md-1 my-5">
            <div class="login-form">
                <form id="loginForm">
                    <div class="avatar">
                        <img src="images/project_logo.png" alt="">
                    </div>
                    <h2 class="text-center">Login</h2>   
                    <div class="form-label-group">
                        <input type="text" id="email" class="form-control" name="email" placeholder="Email" required="required">
                        <label for="email">Email</label>
                    </div> 
                    <div class="form-label-group">
                        <input type="password" id="passcode" class="form-control" name="passcode" placeholder="Passcode" required="required">
                        <label for="passcode">Passcode</label>
                    </div>
                    <div class="form-group">
                        <input type="checkbox" id="showPasscode"> Show Passcode
                    </div> 
                    <div class="form-group">
                        <button type="submit" id="submit" class="btn btn-primary btn-lg btn-block">Sign in</button>
                    </div>
                </form>
                <p id="text"></p>
            </div>
        </div>
    </div>
</div>
<br>

<script src="https://code.jquery.com/jquery-3.5.0.min.js" integrity="sha256-xNzN2a4ltkB44Mc/Jz3pT4iU1cmeR0FkXs4pru/JxaQ=" crossorigin="anonymous"></script>

<script type="text/javascript">
    document.getElementById("email").addEventListener("keyup", checkingCapsLock);
    document.getElementById("showPasscode").addEventListener("change", displayPassword);
    let text = document.getElementById("text");
    let passcode = document.getElementById("passcode");

    $("#submit").click(function (event) 
    {
        event.preventDefault();
        let email = document.getElementById("email").value;
        let passcode = document.getElementById("passcode").value;

        let data = 
        {
            email: email,
            passcode: passcode
        };

        $.ajax
        ({
            type: "POST",
            url: "http://localhost/mediabazaar/mediaBazaarStockManagement/login/loginRequest",
            data: 
            {
                data: data
            },
            success: function (data) 
            {
                if(data == 'success')
                {
                    Swal.fire
                    ({
                        title: "Two-Step Verification",
                        input: 'text',
                        inputAttributes: 
                        {
                            min: 6,
                            max: 6,
                            autocapitalize: 'off'
                        },
                        inputPlaceholder: 'Please enter the code you received via email...',
                        icon: "info",
                        showCancelButton: true,
                        confirmButtonText: 'Confirm',
                        allowOutsideClick: false,
                        timer: 60000,
                        timerProgressBar: true,
                        inputValidator: (value) => 
                        {
                            if (!value) 
                            {
                                return 'Please enter the correct code!'
                            }
                        }
                    })
                    .then(function(isConfirm) 
                    {
                        if (isConfirm) 
                        {
                            $.ajax
                            ({
                                url: 'http://localhost/mediabazaar/mediaBazaarStockManagement/login/loginCodeRequest',
                                type: 'POST',
                                data: {data: isConfirm},
                            })
                            .done(function(data) 
                            {
                                if(data == 'success')
                                {
                                    location.href = "home";
                                }
                                else if(data == 'error')
                                {
                                    Swal.fire
                                    ({
                                        title: "Login Failed",
                                        icon: 'error',
                                        text: 'Please try again!'
                                    });
                                }
                            })
                            .fail(function() 
                            {
                                console.log("error");
                            })
                            .always(function() 
                            {
                                console.log("complete");
                            });
                        } 
                        else 
                        {
                            Swal.fire
                            ({
                              title: 'Oh no, system failure!',
                              text: 'Connection error, please contact your administrator.',
                              icon: 'error',
                            })
                        }
                    });
                }
                else if (data == 'User not found')
                {
                    Swal.fire
                    ({
                      title: 'Error!',
                      text: 'Please enter the correct email.',
                      icon: 'error',
                    })
                }
            }
        });
    })


    function displayPassword() 
    {
        if (passcode.type === "password") 
        {
            passcode.type = "text";
        } 
        else 
        {
            passcode.type = "password";
        }
    }

    function checkingCapsLock(event)
    {
        event.preventDefault();

        if (event.getModifierState("CapsLock")) 
        {
            text.style.display = "block";
            text.innerHTML = "WARNING! Caps lock is ON.";
        } 
        else 
        {
            text.style.display = "none"
        }
    }
</script>