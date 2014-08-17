# Borderline.DbC #

Borderline.DbC is a simple to use library for validating pre- and postconditions.

### Getting started ###

Short introduction how to use the library.

There are two main objects to use:

* **Require** - Used for precondition checks
* **Ensure** - Used for postcondition checks

Use `Ensure` or `Reqiured` to project one or more properties of a given type.

	Require.That(() => obj.Property)

or chain properties

	Require.That(() => Property1).And(() => Property2)

#### Constraints ####

Constraints perform the condition checks and are prefixed with `Is` or `IsNot`. You can chain as many constraints as you like for the specified properties.

##### Object #####

* **Null**

When using `Is` evaluates if an object is null. When using `IsNot` the object can't be null.

	Require.That(() => obj.Property).Is.Null();
	Require.That(() => obj.Property).IsNot.Null();

##### String #####

* **Null**

When using `Is` evaluates if a string is null. When using `IsNot` the string can't be null.

	Require.That(() => obj.Text).Is.Null();
	Require.That(() => obj.Text).IsNot.Null();

* **Empty**

When using `Is` evaluates if a string is empty. When using `IsNot` the string can't be empty.

	Require.That(() => obj.Text).Is.Empty();
	Require.That(() => obj.Text).IsNot.Empty();

* **NullOrEmpty**

When using `Is` evaluates if a string is null or empty. When using `IsNot` the string can't be null or empty.

	Require.That(() => obj.Text).Is.NullOrEmpty();
	Require.That(() => obj.Text).IsNot.NullOrEmpty();

* **EqualTo**

When using `Is` evaluates if a string is equal to the specified value. When using `IsNot` the string can't be equal to the specified value.

	Require.That(() => obj.Text).Is.EqualTo("Hello World!");
	Require.That(() => obj.Text).IsNot.EqualTo("Hello World!");

##### Numeric #####

There are constraints implemented for `short`, `int`, `long`, `double` and `decimal`.

* **EqualTo**

When using `Is` evaluates if a number is equal to the specified value. When using `IsNot` the number can't be equal to the specified value.

	Require.That(() => obj.Text).Is.EqualTo(1);
	Require.That(() => obj.Text).IsNot.EqualTo(1);

* **Ge**

When using `Is` evaluates if a number is greater than or equal to the specified value. When using `IsNot` the number has to be less than the specified value.

	Require.That(() => obj.Text).Is.Ge(1);
	Require.That(() => obj.Text).IsNot.Ge(1);

* **Gt**

When using `Is` evaluates if a number is greater than the specified value. When using `IsNot` the number has to be less than or equal to the specified value.

	Require.That(() => obj.Text).Is.Gt(1);
	Require.That(() => obj.Text).IsNot.Gt(1);

* **Le**

When using `Is` evaluates if a number less than or equal to the specified value. When using `IsNot` the number has to be greater than the specified value.

	Require.That(() => obj.Text).Is.Le(1);
	Require.That(() => obj.Text).IsNot.Le(1);

* **Lt**

When using `Is` evaluates if a number is less than the specified value. When using `IsNot` the number has to be greater than or equal to the specified value.

	Require.That(() => obj.Text).Is.Lt(1);
	Require.That(() => obj.Text).IsNot.Lt(1);

* **Between**

When using `Is` evaluates if a number is between the specified bounds. When using `IsNot` the number has to be outside the bounds.

	Require.That(() => obj.Text).Is.Between(1, 2);
	Require.That(() => obj.Text).IsNot.Between(1, 2);

##### Collections #####

* **Null**

When using `Is` evaluates if a collection is null. When using `IsNot` the collection can't be null.

	Require.That(() => obj.Text).Is.Null();
	Require.That(() => obj.Text).IsNot.Null();

* **Empty**

When using `Is` evaluates if a collection is empty. When using `IsNot` the collection can't be empty.

	Require.That(() => obj.Text).Is.Empty();
	Require.That(() => obj.Text).IsNot.Empty();

* **NullOrEmpty**

When using `Is` evaluates if a collection is null or empty. When using `IsNot` the collection can't be null or empty.

	Require.That(() => obj.Text).Is.NullOrEmpty();
	Require.That(() => obj.Text).IsNot.NullOrEmpty();

### About the author ###

> Working with brilliant people has made me a decent developer. I like to produce clean and aesthetically appealing code.
> - [John Tjust](https://bitbucket.org/glufsaren)