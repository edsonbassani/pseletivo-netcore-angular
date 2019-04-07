import { Component, OnInit } from '@angular/core';
import { Airplaneregister } from 'src/app/shared/airplaneregister.model';
import { AirplaneregisterService } from 'src/app/shared/airplaneregister.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-airplaneregister-list',
  templateUrl: './airplaneregister-list.component.html',
  styles: []
})
export class AirplaneregisterListComponent implements OnInit {

constructor(private service: AirplaneregisterService,

  private toastr: ToastrService) { }



  ngOnInit() {
    this.service.refreshList();
  }
  
  populateForm(ar: Airplaneregister) {

    this.service.formData = Object.assign({}, ar);

  }

  onDelete(id: number) {

    if (confirm('Are you sure to delete this record?')) {

      this.service.deleteAirplaneregister(id).subscribe(res => {

        this.service.refreshList();

        this.toastr.warning('Deleted successfully', 'Airplaneregister');

      });

    }

  }
}
