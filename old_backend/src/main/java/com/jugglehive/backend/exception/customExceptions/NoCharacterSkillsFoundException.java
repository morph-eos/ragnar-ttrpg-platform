package com.jugglehive.backend.exception.customExceptions;

/**
 * Exception thrown when no character skills are found where at least one was expected.
 */
public class NoCharacterSkillsFoundException extends RuntimeException {

    /**
     * Constructs a new NoCharacterSkillsFoundException with the specified detail message.
     *
     * @param message the detail message.
     */
    public NoCharacterSkillsFoundException(String message) {
        super(message);
    }

    /**
     * Constructs a new NoCharacterSkillsFoundException with the specified detail message and cause.
     *
     * @param message the detail message (which is saved for later retrieval by the getMessage() method).
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoCharacterSkillsFoundException(String message, Throwable cause) {
        super(message, cause);
    }

    /**
     * Constructs a new NoCharacterSkillsFoundException with the cause of the throwable.
     *
     * @param cause the cause (which is saved for later retrieval by the getCause() method).
     *               (A null value is permitted, and indicates that the cause is nonexistent or unknown.)
     */
    public NoCharacterSkillsFoundException(Throwable cause) {
        super(cause);
    }
}
