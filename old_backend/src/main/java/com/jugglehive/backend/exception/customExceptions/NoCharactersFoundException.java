package com.jugglehive.backend.exception.customExceptions;

/**
 * Exception thrown when no characters are found where at least one was expected.
 */
public class NoCharactersFoundException extends RuntimeException {

    /**
     * Constructs a new NoCharactersFoundException with the specified detail message.
     *
     * @param message the detail message.
     */
    public NoCharactersFoundException(String message) {
        super(message);
    }

    /**
     * Constructs a new NoCharactersFoundException with the specified detail message and cause.
     *
     * @param message the detail message (which is saved for later retrieval by the getMessage() method).
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoCharactersFoundException(String message, Throwable cause) {
        super(message, cause);
    }

    /**
     * Constructs a new NoCharactersFoundException with the cause of the throwable.
     *
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoCharactersFoundException(Throwable cause) {
        super(cause);
    }
}
