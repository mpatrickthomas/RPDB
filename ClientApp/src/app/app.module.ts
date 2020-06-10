import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { QueenComponent } from './queen/queen.component';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { CreateEditQueenDialogComponent } from './create-edit-queen-dialog/create-edit-queen-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    QueenComponent,
    CreateEditQueenDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'queens/:queenId', component: QueenComponent }
    ]),
    BrowserAnimationsModule,
    CommonModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    CreateEditQueenDialogComponent
  ]
})
export class AppModule { }
