package com.jugglehive.backend.exception.handlers;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;

import com.jugglehive.backend.exception.ExceptionResponse;

//Class to handle default Java exceptions
@ControllerAdvice
public class DefaultExceptionsHandler {

    //Global Exception handler
    @ExceptionHandler(Exception.class)
    public final ResponseEntity<Object> handleAllExceptions(Exception ex, WebRequest request) {
        ExceptionResponse exceptionResponse = new ExceptionResponse();
        exceptionResponse.setUserId(request.getParameter("USER_ID"));
        exceptionResponse.setStatus(HttpStatus.INTERNAL_SERVER_ERROR.value());
        exceptionResponse.setMessage(ex.getMessage());
        exceptionResponse.setDetails(request.getDescription(false));
        exceptionResponse.setExceptionClass(ex.getClass().getSimpleName());
        return new ResponseEntity<>(exceptionResponse, HttpStatus.INTERNAL_SERVER_ERROR);
    }

    //IndexOutOfBoundsException handler
    @ExceptionHandler(IndexOutOfBoundsException.class)
    public final ResponseEntity<Object> handleIndexOutOfBoundsException(IndexOutOfBoundsException ex, WebRequest request) {

        ExceptionResponse exceptionResponse = new ExceptionResponse();
        exceptionResponse.setUserId(request.getParameter("USER_ID"));
        exceptionResponse.setStatus(HttpStatus.BAD_REQUEST.value());
        exceptionResponse.setMessage(ex.getMessage());
        exceptionResponse.setDetails(request.getDescription(false));
        exceptionResponse.setExceptionClass(ex.getClass().getSimpleName());
        return new ResponseEntity<>(exceptionResponse, HttpStatus.BAD_REQUEST);
    }


    // IllegalArgumentException handler
    @ExceptionHandler(IllegalArgumentException.class)
    public final ResponseEntity<Object> handleIllegalArgumentException(IllegalArgumentException ex, WebRequest request) {
        ExceptionResponse exceptionResponse = new ExceptionResponse();
        exceptionResponse.setUserId(request.getParameter("USER_ID"));
        exceptionResponse.setStatus(HttpStatus.BAD_REQUEST.value());
        exceptionResponse.setMessage("Invalid argument: " + ex.getMessage());
        exceptionResponse.setDetails(request.getDescription(false));
        exceptionResponse.setExceptionClass(ex.getClass().getSimpleName());
        return new ResponseEntity<>(exceptionResponse, HttpStatus.BAD_REQUEST);
    }


}


