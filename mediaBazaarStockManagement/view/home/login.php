    <div class="container-fluid">
        <div class="row align-items-center">

            <div class="col-12 col-md-6 offset-xl-2 offset-md-1 order-md-2 mb-5 mb-md-0">
                <!-- Image -->
                <!-- <div id="clock"></div> -->
                <div class="text-center">
                    <img src="images/warehouse-industrial.jpg" alt="..." class="img-fluid">
                </div>
            </div>

            <div class="col-12 col-md-5 col-xl-4 order-md-1 my-5">
                <div class="login-form">
                    <form action="<?= URL ?>login/login" method="post" id="loginForm">
                        <div class="avatar">
                            <img src="images/project_logo.png" alt="">
                        </div>
                        <h2 class="text-center">Login</h2>   
                        <div class="form-label-group">
                            <input type="password" id="passcode" class="form-control" name="passcode" placeholder="Passcode" required="required">
                            <label for="passcode">Passcode</label>
                        </div>
                        <div class="form-group">
                            <input type="checkbox" id="showPasscode">Show Passcode
                        </div>       
                        <div class="form-group">
                            <button type="submit" class="btn btn-primary btn-lg btn-block">Sign in</button>
                        </div>
                    </form>
                    <p id="text"></p>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>

<script src="https://code.jquery.com/jquery-3.5.0.min.js" integrity="sha256-xNzN2a4ltkB44Mc/Jz3pT4iU1cmeR0FkXs4pru/JxaQ=" crossorigin="anonymous"></script>

<script type="text/javascript">
    document.getElementById("showPasscode").addEventListener("change", displayPassword);
    document.getElementById("passcode").addEventListener("keyup", checkingCapsLock);
    let passcode = document.getElementById("passcode");
    let text = document.getElementById("text");

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