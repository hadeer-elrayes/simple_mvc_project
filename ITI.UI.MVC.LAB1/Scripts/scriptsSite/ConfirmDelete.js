function confirmDelete( id) {
    let result = confirmDelete("Are You Sure")
    if (result) {
        location.href = (`/Empolyees/delete/${id}`);
    }
}