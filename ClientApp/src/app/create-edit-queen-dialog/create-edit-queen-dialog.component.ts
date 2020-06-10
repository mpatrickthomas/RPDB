import { Component, Inject, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Queen, Season } from '../interfaces';
import { MaterialModule } from '../material.module';

@Component({
    selector: 'app-create-edit-queen-dialog',
    templateUrl: './create-edit-queen-dialog.component.html',
    styleUrls: ['./create-edit-queen-dialog.component.css']
})
/** create-edit-queen-dialog component*/
export class CreateEditQueenDialogComponent {
  selectedSeasons: string[];
  newSeasonFormControl = new FormControl('');

  constructor(
    public dialogRef: MatDialogRef<CreateEditQueenDialogComponent>,
    private snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditQueenDialogData,
    ) {

    if (!data.queen) this.data.queen = <Queen>{};

    if (!data.availableSeasons){
      console.log("No season data was returned");
      this.data.availableSeasons = <Season[]>{};
    } 
    else if(data.queen.queenSeasons && data.queen.queenSeasons.length > 0){
      this.selectedSeasons = this.data.availableSeasons
                              .filter((season) => 
                                      this.data.queen.queenSeasons.map(qs => 
                                          qs.season).some(s => 
                                            s.name === season.name))
                              .map(s => s.name);
    }
    else {
      this.selectedSeasons = [];
    }
  }

  onNoClick() {
    this.dialogRef.close();
  }

  onSubmitNewSeason(){
    console.log("new season is " + this.newSeasonFormControl.value);

  }

  onSubmit() {
    this.dialogRef.close();
    if(this.data.queen.name) this.snackBar.open('Submitted ' + this.data.queen.name + '!');
  }
}

export interface CreateEditQueenDialogData{
  queen: Queen;
  availableSeasons: Season[];
}
