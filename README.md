# Borderline.DbC #

Borderline.DbC is a simple to use library for validating pre- and postconditions.

### Getting started ###

Short introduction how to use the library.

There is two main objects to use:

* **Require** - Used for precondition checks
* **Ensure** - Used for postcondition checks

Use Ensure or Reqiured to project one or more properties of a given type.

	Require.That(() => obj.Property)

or chain properties

	Require.That(() => Property1).And(() => Property2)

#### Constraints ####

Constraints perform the condition checks and are prefixed with `Is` or `IsNot`. You can chain as many constraints as you like for the spec

##### Object #####

* Null - Evaluates if an object is null

	Require.That(() => obj.Property).Is.Null();
	Require.That(() => obj.Property).IsNot.Null();

##### String #####

* NullOrEmpty 

When using `Is` evaluates if a string is null or empty. When using `IsNot` the string can't be null or empty.

	Require.That(() => obj.Text).Is.NullOrEmpty();
	Require.That(() => obj.Text).IsNot.NullOrEmpty();

* Empty

	Require.That(() => obj.Text).Is.Empty();
	Require.That(() => obj.Text).IsNot.Empty();

* Null

	Require.That(() => obj.Text).Is.Null();
	Require.That(() => obj.Text).IsNot.Null();

* EqualTo

	Require.That(() => obj.Text).Is.EqualTo("Hello World!");
	Require.That(() => obj.Text).IsNot.EqualTo("Hello World!");

##### int #####


##### Collections #####


### About the author ###

> Working with brilliant people has made me a decent developer. I like to produce clean and aesthetically appealing code.
> - [John Tjust](https://bitbucket.org/glufsaren)