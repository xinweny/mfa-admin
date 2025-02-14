from typing import TypeVar
from math import ceil
from sqlalchemy import func, select
from sqlalchemy.orm import Session, DeclarativeBase
from sqlalchemy.sql.expression import Select
from pydantic import BaseModel, Field

M = TypeVar('M', bound=DeclarativeBase)

class PaginationRequest(BaseModel):
    page: int = Field(1, ge=1)
    limit: int | None = Field(None, ge=1)
    
class PaginationMetadata(BaseModel):
    current_page: int
    total_pages: int
    total_count: int
    page_size: int | None

def get_pagination_metadata(
    query: Select[tuple[M]],
    params: PaginationRequest,
    db: Session,
) -> PaginationMetadata:
    page = params.page
    limit = params.limit
    
    total_count = int(db.execute(select(func.count).select_from(query.subquery())).scalar_one()) or 0
    
    total_pages = ceil(total_count / limit) if limit is not None else 1
  
    return PaginationMetadata(
        current_page=page if page <= total_pages else total_pages,
        total_pages=total_pages,
        total_count=total_count,
        page_size=limit,
    )
    
def paginate(
    query: Select[tuple[M]],
    params: PaginationRequest,
) -> Select[tuple[M]]:
    offset = None if params.limit is None else ((params.page - 1) * params.limit)
    
    paginated_query = query.offset(offset).limit(params.limit)
    
  
    return paginated_query
