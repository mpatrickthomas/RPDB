import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Queen, Season } from '../interfaces';
import { MatDialog } from '@angular/material';
import { CreateEditQueenDialogComponent } from '../create-edit-queen-dialog/create-edit-queen-dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  queens;
  genres;
  seasons;
  editedQueen;

  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      public dialog: MatDialog
  )
  {
      this.http.get<Queen[]>(baseUrl + 'api/Queens').subscribe(
        result => this.queens = result, 
        error => console.error(error)
      );

      this.http.get<Season[]>(baseUrl + 'api/Seasons').subscribe(
        result => this.seasons = result, 
        error => console.log(error)
      );
  } 

  openCreateEditQueenDialog(queen: Queen, seasons: Season[]) {
    const dialogRef = this.dialog.open(CreateEditQueenDialogComponent, {
      width: '50%',
      data: {queen: queen, availableSeasons: seasons}
    });

    dialogRef.afterClosed().subscribe(result => this.editedQueen = result);
  }
}
