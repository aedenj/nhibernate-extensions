NHibernate Extensions
=====================

Currently there is only one custom type. Others to follow.


### Salted & Encrypted Property ###

  This is a custom type that will encrypt and decrypt a string property of a class. Encryption automatically
happens when the object is flushed to the persistence store and decrypted when a object is hydrated.

The best way to get started is to look at the spec project. Specifically take a look at how the User model is configured in User.cs.
