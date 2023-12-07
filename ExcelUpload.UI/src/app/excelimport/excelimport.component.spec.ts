import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcelimportComponent } from './excelimport.component';

describe('ExcelimportComponent', () => {
  let component: ExcelimportComponent;
  let fixture: ComponentFixture<ExcelimportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExcelimportComponent]
    });
    fixture = TestBed.createComponent(ExcelimportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
