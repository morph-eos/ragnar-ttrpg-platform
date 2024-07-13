package com.jugglehive.backend.exception.customExceptions;

/**
 * Exception thrown when no baseStats are found where at least one was expected.
 */
public class NoBaseStatsFoundException extends RuntimeException{

    /**
     * Constructs a new NoBaseStatsFoundException with the specified detail message.
     *
     * @param message the detail message.
     */
    public NoBaseStatsFoundException(String message) {
        super(message);
    }

    /**
     * Constructs a new NoBaseStatsFoundException with the specified detail message and cause.
     *
     * @param message the detail message (which is saved for later retrieval by the getMessage() method).
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoBaseStatsFoundException(String message, Throwable cause) {
        super(message, cause);
    }

    /**
     * Constructs a new NoBaseStatsFoundException with the cause of the throwable.
     *
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoBaseStatsFoundException(Throwable cause) {
        super(cause);
    }
}
