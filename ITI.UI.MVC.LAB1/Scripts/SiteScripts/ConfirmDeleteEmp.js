function ConfirmDelete(id)
{
    let Result =confirm("Are you sure ?");
    if (Result) {
        location.href = `/empolyees/delete/${id}`;
    }
}