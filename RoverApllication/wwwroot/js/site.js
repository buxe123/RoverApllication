// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $('#frmForm').on('select change', function () {
        debugger;
        var selectedTextRover1 = $('#roverInput1 :selected').text();
        var selectedMovementRover1 = $('#roverCommand1 :selected').val();

        //Rover 2
        var selectedTextRover2 = $('#roverInput2 :selected').text();
        var selectedMovementRover2 = $('#roverCommand2 :selected').val();

        if (selectedTextRover1 != "NULL" && selectedMovementRover1 != "default") {
            document.getElementById("btnRover1").disabled = false;

            $('.Rover2').attr('disabled', true);
            $('#btnRover1').css("background-color", "green");
        }
        else {

            if (selectedTextRover2 != "NULL" && selectedMovementRover2 != "default") {
                document.getElementById("btnRover2").disabled = false;
                $('.Rover1').attr('disabled', true);
                $('#btnRover2').css("background-color", "green");

            }
            else {
                return;
            }
        }       

    });


   

    $(".btnSendRoverCommand").click(function () {

        //Rover 1
        var selectedTextRover1 = $('#roverInput1 :selected').text();
        var selectedMovementRover1 = $('#roverCommand1 :selected').val();


        //Rover2
        var selectedTextRover2 = $('#roverInput2 :selected').text();
        var selectedMovementRover2 = $('#roverCommand2 :selected').val();


        if (selectedTextRover2 != 'NULL' && selectedMovementRover2 != 'NULL') {
            inputCommand = selectedMovementRover2;
            position = selectedTextRover2;
            var Rover2 = true;
        }
        else if (selectedTextRover1 != 'NULL' && selectedMovementRover1 != 'NULL') {

            inputCommand = selectedMovementRover1;
            position = selectedTextRover1;
            var Rover1 = true;

        }

        if (inputCommand != 'Command') {

            //Rover 1
            if (Rover1) {
                $.ajax(
                    {
                        type: "POST",
                        url: "/Rover/Index",
                        data: { inputCommand, position },
                        dataType: 'json',
                        success: function (data) {

                            var output;

                            if (position === 'LMLMLMLMM') {

                                output = "Direction:" + "   " + " " + data["x"] + " " + data["y"] + " " + data["direction"];
                            }
                            else if (position === '1 2 N') {
                                output = "Direction:" + "   " + data["direction"];
                            }

                            $('.output1').show();
                            $("#lblOutput1").text(output);

                            document.getElementById("btnRover2").disabled = true;
                            $('#btnRover1').removeAttr('style');


                        },
                        error: function (error) {
                            console.log('Error occured', error.responseText);
                           
                        }
                    });
            }

            //Rover 2
            else if (Rover2) {
                $.ajax(
                    {
                        type: "POST",
                        url: "/Rover/Index",
                        data: { inputCommand, position },
                        dataType: 'json',
                        success: function (data) {

                            var output;

                            if (position === 'MMRMMRMRRM') {

                                output = "Direction:" + "   " + " " + data["x"] + " " + data["y"] + " " + data["direction"];
                            }
                            else if (position === '3 3 E') {
                                output = "Direction:" + "   " + data["direction"];
                            }

                            $('.output2').show();
                            $("#lblOutput2").text(output);

                            document.getElementById("btnRover1").disabled = true;
                            $('#btnRover2').removeAttr('style');

                        },
                        error: function (error) {
                            console.log('Error occured', error.responseText);                           
                        },
                    });
            }
        }
        else {

            //Rover 1
            if (Rover1) {

                //Rover to  arrive to specific position
                position = "1 2 N"
                inputCommand = "LMLMLMLMM";
            
                $.ajax(
                    {
                        type: "POST",
                        url: "/Rover/Command",
                        data: { inputCommand, position },
                        dataType: 'json',
                        success: function (data) {

                            var output;

                            output = "Direction:" + "   " + data["x"] + " " + data["y"] + " " + data["direction"];                          
                          
                                $('.output1').show();
                                $("#lblOutput1").text(output);
                            
                            document.getElementById("btnRover2").disabled = true;
                            $('#btnRover1').removeAttr('style');

                        },
                        error: function (error) {
                            console.log('Error occured', error.responseText);
                        },
                    });
            }

            //Rover 2
            else if (Rover2) {

                //Rover to  arrive to specific position
                position = "3 3 E"
                inputCommand = "MMRMMRMRRM";
                $.ajax(
                    {
                        type: "POST",
                        url: "/Rover/Command",
                        data: { inputCommand, position },
                        dataType: 'json',
                        success: function (data) {

                            var output;

                            output = "Direction:" + "   " + data["x"] + " " + data["y"] + " " + data["direction"];
                            
                                $('.output2').show();
                                $("#lblOutput2").text(output);
                          
                            
                            document.getElementById("btnRover1").disabled = true;
                            $('#btnRover2').removeAttr('style');

                        },
                        error: function (error) {
                            console.log('Error occured', error.responseText);
                            
                        },
                    });

            }
        }
    });

    });  