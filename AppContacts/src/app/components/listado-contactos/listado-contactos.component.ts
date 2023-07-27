import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Contacto } from 'src/app/interfaces/contacto';
import { ContactoService } from 'src/app/services/contacto.service';
import { MAT_DATE_FORMATS  } from "@angular/material/core";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


export const MY_DATA_FORMATS={
  parse:{
    dateInput: 'DD/MM/YYYY'
  },
  display:{
    dateInput: 'DD/MM/YYYY',
    monthYearLabel:'MMMM YYYY'
  }
}

@Component({
  selector: 'app-listado-contactos',
  templateUrl: './listado-contactos.component.html',
  styleUrls: ['./listado-contactos.component.css'],
  providers:[
    {provide:MAT_DATE_FORMATS,useValue:MY_DATA_FORMATS}
  ]
})
export class ListadoContactosComponent implements OnInit, AfterViewInit {
  
  formularioBusqueda:FormGroup;
  displayedColumns: string[] = ['firstName', 'secondName', 'dateBirth', 'adresses', 'phoneNumber', 'acciones'];
  dataInicio:Contacto[]=[];
  dataSource=new MatTableDataSource(this.dataInicio);
  loading:boolean=false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private fb:FormBuilder,private _snackBar:MatSnackBar, private _contactoService:ContactoService){
    this.formularioBusqueda=fb.group({
      ageinit:[""],
      agefinal:[""]
      
  })

  
 }

  ngOnInit(): void {
    this.obtenerContactos();
  }


  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort=this.sort; 
  }

  applyFilter(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter=filterValue.trim().toLowerCase();
   
  }

  obtenerContactos(){
    this.loading=true;
    this._contactoService.getContacts("").subscribe({
      next:(data)=>{
        ;
        this.loading=false;
        if (data.isOk) 
        {        
          this.dataSource.data=data.result;
        }         
      },
      error:(e)=>{
        this.loading=false;
        alert(e.message);
      }
    })
  }
 

  eliminarContacto(id:number){
    this.loading=true;

    this._contactoService.deleteContact(id).subscribe({
      next:(data)=>{
        this.loading=false;    
      },
      complete:()=>{
          this.mensajeExito("Deleted Successfully!!");
          this.obtenerContactos();
      },
      error:(e)=>{
        this.loading=false;
        alert(e.message);
      }
    })
}

buscarRangoEdad(){

  if (this.formularioBusqueda.value.ageinit === "" || this.formularioBusqueda.value.agefinal === "" ) {
    this.obtenerContactos();
  }else{
      this._contactoService.getByRange(this.formularioBusqueda.value.ageinit,this.formularioBusqueda.value.agefinal)
  .subscribe({
    next:(data)=>{
      if (data.isOk){     
        this.dataSource.data=data.result;
      }
      
      else
        this.mensajeExito("Results not not Found");     
    },
    error:(e)=>{}
  })

  }



}

mensajeExito(msg:string){
  this.loading=false;
  this._snackBar.open(msg,'',{
    duration: 4000,
    horizontalPosition:'right'

  });
}
}
