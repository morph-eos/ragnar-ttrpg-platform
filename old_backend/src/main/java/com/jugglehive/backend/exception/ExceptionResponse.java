package com.jugglehive.backend.exception;

import java.sql.Timestamp;

import lombok.Data;

//Class that represents the http responseBody sent to the client when an exception is thrown
@Data
public class ExceptionResponse {

    private int status;
    private String message;
    private String details;
    private Timestamp timestamp = new Timestamp(System.currentTimeMillis());
    private String userId;
    private String sessionInfo;
    private String exceptionClass;
   
}
