import { Component, OnInit } from '@angular/core';
import { AirplaneregisterService } from 'src/app/shared/airplaneregister.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-airplaneregister',
  templateUrl: './airplaneregister.component.html',
  styles: []
})
export class AirplaneregisterComponent implements OnInit {

  constructor(private service:AirplaneregisterService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null)
      form.resetForm();

    this.service.formData = {
      Id :0,
      AirplaneTypeId :0,
      Capacity :0,
      Created :""
    }
  }

  onSubmit(form: NgForm) {

    if (form.value.Id == null) 
        form.value.Id = 0;

    if(form.value.Id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
      this.service.postAirplaneRegister(form.value).subscribe(res => {
      this.toastr.success('Inserted successfully', 'AirplaneRegister');
      this.resetForm(form);
      this.service.refreshList();
    },err => {
      this.toastr.error('An error has occurred', 'AirplaneRegister');
      console.log(err);
    });

  }



  updateRecord(form: NgForm) {

    this.service.putAirplaneRegister(form.value).subscribe(res => {

      this.toastr.info('Updated successfully', 'AirplaneRegister');

      this.resetForm(form);

      this.service.refreshList();

    },err => {
      this.toastr.error('An error has occurred', 'AirplaneRegister');
      console.log(err);
    });

  }

}
